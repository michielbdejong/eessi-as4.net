import { BoxComponent } from './../../common/box/box.component';
import { Subscription } from 'rxjs/Subscription';
import { FormGroup, FormBuilder, FormArray, FormControl, AbstractControl } from '@angular/forms';
import { Component, ViewChildren, QueryList } from '@angular/core';

import { ReceivingPmode } from './../../api/ReceivingPmode';
import { PmodesModule } from '../pmodes.module';
import { PmodeStore } from '../pmode.store';
import { PmodeService, pmodeService } from '../pmode.service';
import { DialogService } from './../../common/dialog.service';
import { ItemType } from './../../api/ItemType';
import { RuntimeStore } from './../../settings/runtime.store';
import { SendingPmode } from './../../api/SendingPmode';
import { ReceivingProcessingMode } from './../../api/ReceivingProcessingMode';
import { getRawFormValues } from './../../common/getRawFormValues';

@Component({
    selector: 'as4-receiving-pmode',
    templateUrl: './receivingpmode.component.html',
    styles: [require('./receivingpmode.component.scss').toString()]
})
export class ReceivingPmodeComponent {
    public form: FormGroup;
    public pmodes: string[];
    public isNewMode: boolean = false;
    public deliverSenders: Array<ItemType>;
    @ViewChildren(BoxComponent) boxes: QueryList<BoxComponent>;
    public get currentPmode(): ReceivingPmode | undefined {
        return this._currentPmode;
    }
    public set currentPmode(pmode: ReceivingPmode | undefined) {
        this._currentPmode = pmode;
        if (!!!pmode) this.form.disable();
        else this.form.enable();
    }
    private _storeSubscription: Subscription;
    private _currentPmodeSubscription: Subscription;
    private _runtimeStoreSubscription: Subscription;
    private _currentPmode: ReceivingPmode | undefined;
    constructor(private formBuilder: FormBuilder, private pmodeService: PmodeService, private pmodeStore: PmodeStore, private dialogService: DialogService, private runtimeStore: RuntimeStore) {
        this.form = ReceivingPmode.getForm(this.formBuilder, null);
        setTimeout(() => this.form.disable());
        this._runtimeStoreSubscription = this.runtimeStore
            .changes
            .filter(result => !!result)
            .map(result => result.deliverSenders)
            .distinctUntilChanged()
            .subscribe(result => this.deliverSenders = result);
        this._storeSubscription = this.pmodeStore
            .changes
            .filter(result => !!result)
            .map(result => result.ReceivingNames)
            .distinctUntilChanged()
            .subscribe(result => this.pmodes = result);
        this._currentPmodeSubscription = this.pmodeStore
            .changes
            .filter(result => !!result)
            .map(result => result.Receiving)
            .distinctUntilChanged()
            .subscribe(result => {
                this.currentPmode = result;
                ReceivingPmode.patchForm(this.formBuilder, this.form, result);
                // this.form.reset(result);
            });
        this.pmodeService.getAllReceiving();
    }
    public pmodeChanged(name: string) {
        let select = () => {
            this.isNewMode = false;
            let lookupPmode = this.pmodes.find(pmode => pmode === name);
            if (!!lookupPmode) this.pmodeService.getReceiving(name);
            else this.pmodeStore.setReceiving(undefined);
            this.form.markAsPristine();
        };
        if (this.form.dirty) {
            this.dialogService
                .confirmUnsavedChanges()
                .filter(result => result)
                .subscribe(() => {
                    if (this.isNewMode) {
                        this.pmodes = this.pmodes.filter(pmode => pmode !== this.currentPmode.name);
                        this.isNewMode = false;
                    }
                    else select();
                });
            return false;
        }

        select();
        return true;
    }
    public rename() {
        this.dialogService
            .prompt('Please enter a new name')
            .filter(result => !!result)
            .subscribe(newName => {
                this.form.patchValue({ [ReceivingPmode.FIELD_name]: newName });
                this.form.markAsDirty();
            });
    }
    public reset() {
        if (this.isNewMode) {
            this.isNewMode = false;
            this.pmodes = this.pmodes.filter(pmode => pmode !== this.currentPmode.name);
            this.currentPmode = undefined;
        }
        ReceivingPmode.patchForm(this.formBuilder, this.form, this.currentPmode);
        this.form.reset(this.currentPmode);
        this.form.markAsPristine();
    }
    public delete() {
        if (!!!this.currentPmode) return;
        this.dialogService
            .deleteConfirm('pmode')
            .filter(result => result)
            .subscribe(result => this.pmodeService.deleteReceiving(this.currentPmode.name));
    }
    public add() {
        this.dialogService
            .prompt('Please enter a new name', 'New pmode')
            .filter(result => !!result)
            .subscribe(newName => {
                if (!!!newName) return;
                let newPmode = new ReceivingPmode();
                newPmode.name = newName;
                newPmode.pmode = new ReceivingProcessingMode();
                newPmode.pmode.id = newName;
                this.currentPmode = newPmode;
                this.pmodes.push(newName);
                this.isNewMode = true;
                ReceivingPmode.patchForm(this.formBuilder, this.form, this.currentPmode);
                this.form.markAsDirty();
            });
    }
    public save() {
        if (this.form.invalid) {
            this.dialogService.incorrectForm();
            return;
        }

        if (this.isNewMode) {
            this.pmodeService
                .createReceiving(getRawFormValues(this.form))
                .subscribe(() => {
                    this.isNewMode = false;
                    this.form.markAsPristine();
                });
            return;
        }

        this.pmodeService
            .updateReceiving(getRawFormValues(this.form), this.currentPmode.name)
            .subscribe(() => {
                this.isNewMode = false;
                this.form.markAsPristine();
            });
    }
    public expand() {
        let index = 0;
        this.boxes
            .filter(box => box.collapsible && ++index > 0)
            .forEach(box => box.collapsed = !box.collapsed);
    }
    ngOnDestroy() {
        this._storeSubscription.unsubscribe();
        this._currentPmodeSubscription.unsubscribe();
        this._runtimeStoreSubscription.unsubscribe();
    }
    ngAfterViewInit() {
        this.expand();
    }
}
