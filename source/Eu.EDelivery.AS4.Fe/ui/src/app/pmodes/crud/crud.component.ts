import { Component, Inject, Input, OnDestroy, OnInit, OpaqueToken } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

import { ICrudPmodeService } from '../crudpmode.service.interface';
import { IPmode } from './../../api/Pmode.interface';
import { DialogService } from './../../common/dialog.service';
import { getRawFormValues } from './../../common/getRawFormValues';
import { ModalService } from './../../common/modal/modal.service';
import { RouterService } from './../../common/router.service';

export const PMODECRUD_SERVICE = new OpaqueToken('pmodecrudservice');

@Component({
  selector: 'as4-pmode',
  template: `
    <as4-modal
      name="new-pmode"
      title="Create a new pmode"
      (shown)="actionType = pmodes[0]; newName = ''; nameInput.focus()"
      focus
    >
      <form class="form-horizontal">
        <div class="form-group">
          <label class="col-xs-2">New name</label>
          <div class="col-xs-10">
            <input
              type="text"
              class="form-control"
              #nameInput
              (keyup)="newName = $event.target.value"
              [value]="newName"
              focus
            />
          </div>
        </div>
        <div class="form-group">
          <label class="col-xs-2">Based on</label>
          <div class="col-xs-10">
            <select
              class="form-control"
              (change)="actionType = $event.target.value"
              #select
            >
              <option [selected]="actionType === 'Empty'" value=""
                >Empty</option
              >
              <option
                [selected]="actionType === setting"
                *ngFor="let setting of pmodes"
                [ngValue]="setting"
                >{{ setting }}</option
              >
            </select>
          </div>
        </div>
      </form>
    </as4-modal>
    <as4-input label="Name" runtimeTooltip="receivingprocessingmode.id">
      <as4-columns noMargin="true">
        <select
          class="FormArray-control select-pmode"
          data-cy="select-pmodes"
          as4-no-auth
          (change)="
            pmodeChanged($event.target.value);
            pmodeSelect.value = currentPmode && currentPmode.pmode.id
          "
          #pmodeSelect
        >
          <option value="undefined">Select an option</option>
          <option
            *ngFor="let pmode of pmodes"
            [attr.data-cy]="pmode.id"
            [selected]="pmode === (currentPmode && currentPmode.pmode.id)"
            >{{
              currentPmode &&
              currentPmode.pmode.id === pmode &&
              !!form &&
              !!form.controls &&
              !!form.controls.pmode &&
              !!form.controls.pmode.controls.id
                ? form.controls.pmode.controls.id.value
                : pmode
            }}</option
          >
        </select>
        <div
          crud-buttons
          [form]="form"
          (add)="add()"
          (rename)="rename()"
          (reset)="reset()"
          (delete)="delete()"
          (save)="save()"
          [current]="currentPmode"
          [isNewMode]="isNewMode"
        ></div>
      </as4-columns>
    </as4-input>
    <ng-content></ng-content>
  `
})
export class CrudComponent implements OnInit, OnDestroy {
  public isNewMode: boolean = false;
  public pmodes: string[];
  public form: FormGroup;
  public currentPmode: IPmode | undefined;
  @Input() public actionType: string;
  public newName: string;
  private subscriptions: Subscription[] = new Array<Subscription>();
  constructor(
    private _dialogService: DialogService,
    @Inject(PMODECRUD_SERVICE) private _crudService: ICrudPmodeService,
    private _modalService: ModalService,
    private _activatedRoute: ActivatedRoute,
    private _router: Router,
    private _routerService: RouterService
  ) {
    this.form = this._crudService.getForm(undefined).build(true);
  }
  public ngOnInit() {
    let compareTo: string | null = this._activatedRoute.snapshot.queryParams[
      'compareto'
    ];
    if (!!!this._activatedRoute.snapshot.params['pmode']) {
      this._crudService.get(null);
    }

    this.subscriptions.push(
      this._crudService.obsGetAll().subscribe((result) => {
        this.pmodes = !!!result ? new Array<string>() : result.sort();
        if (!!!result) {
          return;
        }

        let pmodeQueryParam = this._activatedRoute.snapshot.params['pmode'];
        if (!!!pmodeQueryParam) {
          return;
        }
        if (result.length === 0) {
          return;
        }
        // Validate that the requested pmode exists
        let exists = result.find((search) => search === pmodeQueryParam);
        if (!!!exists) {
          this._dialogService.message(`PMode ${pmodeQueryParam} doesn't exist`);
          compareTo = null;
          return;
        }
        this._crudService.get(pmodeQueryParam);
      })
    );
    this.subscriptions.push(
      this._crudService.obsGet().subscribe((result) => {
        this.currentPmode = result;
        this.form = this._crudService.getForm(result).build(!!!result);
        this.form.markAsPristine();
        if (!!!result && !!!this.currentPmode) {
          this._routerService.setCurrentValue(this._activatedRoute, null);
          return;
        }
        if (!!!result) {
          return;
        }
        if (!!result && !!compareTo && compareTo !== result.hash) {
          this._dialogService.error(
            `PMode used in the message doesn't match anymore.`
          );
        }
        compareTo = null;
        this._routerService.setCurrentValue(
          this._activatedRoute,
          result.pmode.id
        );
      })
    );
  }
  public ngOnDestroy() {
    this.subscriptions.forEach((subs) => subs.unsubscribe());
    if (this.isNewMode) {
      // Reset the state when the component is being destroyed
      this.reset();
    }
  }
  public pmodeChanged(name: string) {
    let select = () => {
      this.isNewMode = false;
      this._crudService.get(name);
    };
    if ((this.form.dirty || this.isNewMode) && !!this.currentPmode) {
      this._dialogService
        .confirmUnsavedChanges()
        .filter((result) => result)
        .subscribe(() => {
          if (this.isNewMode) {
            this.pmodes = this.pmodes.filter(
              (pmode) => pmode !== this.currentPmode!.pmode.id
            );
            this.isNewMode = false;
          }
          select();
        });
      return false;
    }

    select();
    return true;
  }
  public reset() {
    if (!!!this.currentPmode) {
      return;
    }
    if (this.isNewMode) {
      this.isNewMode = false;
      this.pmodes = this.pmodes.filter(
        (pmode) => pmode !== this.currentPmode!.name
      );
      // The pmode can be removed from the store because it isn't used anymore, but don't call the REST service.
      this._crudService.delete(this.currentPmode!.name, true);
      this.currentPmode = undefined;
    }
    this.form = this._crudService
      .getForm(this.currentPmode)
      .build(!!!this.currentPmode);
    if (!!!this.currentPmode) {
      this._routerService.setCurrentValue(this._activatedRoute, null);
    }
  }
  public delete() {
    if (!!!this.currentPmode) {
      return;
    }
    this._dialogService
      .deleteConfirm('pmode')
      .filter((result) => result)
      .subscribe((result) => {
        this._crudService.delete(this.currentPmode!.name, this.isNewMode);
        this.isNewMode = false;
        this._routerService.setCurrentValue(this._activatedRoute, null);
      });
  }
  public add() {
    this._modalService
      .show('new-pmode')
      .filter((result) => result)
      .subscribe(() => {
        if (this.checkIfExists(this.newName)) {
          return;
        }
        if (!!!this.newName) {
          return;
        }
        if (!!this.actionType) {
          this._crudService
            .getByName(this.pmodes.find((name) => name === this.actionType)!)
            .subscribe((existingPmode) => {
              this.currentPmode = Object.assign({}, existingPmode);
              this.currentPmode.name = this.newName;
              this.currentPmode.pmode.id = this.newName;
              this.afterAdd();
            });
          return;
        }
        this.currentPmode = this._crudService.getNew(this.newName);
        this.afterAdd();
      });
  }
  public rename() {
    if (this.currentPmode) {
      this.newName = this.form.get('name')!.value;

      this._dialogService
        .prompt('Please enter a new name', 'Rename', this.newName)
        .filter((result) => !!result)
        .subscribe((newName) => {
          if (this.checkIfExists(newName)) {
            return;
          }

          this._crudService.patchName(this.form, newName);

          this.pmodes = this.pmodes.filter((p) => p !== this.newName);
          this.pmodes.push(newName);
          this.currentPmode!!.pmode!!.id = newName;

          this.form.markAsDirty();
          this._routerService.setCurrentValue(this._activatedRoute, newName);
        });
    }
  }
  public save() {
    if (!!!this.currentPmode) {
      return;
    }
    if (this.form.invalid) {
      this._dialogService.incorrectForm();
      return;
    }

    if (this.isNewMode) {
      this._crudService.create(getRawFormValues(this.form)).subscribe(() => {
        this.isNewMode = false;
        this.form.markAsPristine();
      });
      return;
    }

    this._crudService
      .update(getRawFormValues(this.form), this.currentPmode.name)
      .subscribe(() => {
        this.isNewMode = false;
        this.form.markAsPristine();
      });
  }
  private checkIfExists(name: string): boolean {
    let exists =
      this.pmodes.findIndex(
        (pmode) => pmode.toLowerCase() === name.toLowerCase()
      ) > -1;
    if (exists) {
      this._dialogService.message(`Pmode with name ${name} already exists`);
    }
    return exists;
  }
  private afterAdd() {
    this.pmodes.push(this.newName);
    this.isNewMode = true;
    this.form = this._crudService.getForm(this.currentPmode).build();
    this.form.markAsDirty();
    this._routerService.setCurrentValue(this._activatedRoute, null);
  }
}
