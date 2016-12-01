import { RuntimeService } from './runtime.service';
import { SettingsService } from './settings.service';
import { Component, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AUTH_PROVIDERS } from 'angular2-jwt';

import { As4ComponentsModule } from '../common';

import { SettingsComponent } from './settings.component';
import { StepSettingsComponent } from './step.component';
import { BaseSettingsComponent } from './base.component';
import { CommonSettingsComponent } from './custom.component';
import { DatabaseSettingsComponent } from './database.component';
import { AgentSettingsComponent } from './agent.component';
import { ReceiverComponent } from './receiver.component';
import { DecoratorComponent } from './decorator.component';
import { Store } from '../common/store';
import { SettingsStore } from './settings.store';
import { RuntimeStore } from './runtime.store';
import { ROUTES } from './settings.routes';


@NgModule({
    declarations: [
        SettingsComponent,
        BaseSettingsComponent,
        CommonSettingsComponent,
        DatabaseSettingsComponent,
        AgentSettingsComponent,
        ReceiverComponent,
        DecoratorComponent,
        StepSettingsComponent
    ],
    providers: [
        SettingsService,
        RuntimeService,

        SettingsStore,

        RuntimeStore,

        AUTH_PROVIDERS
    ],
    imports: [
        CommonModule,
        As4ComponentsModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(ROUTES)
    ],
    exports: [
        SettingsComponent,
        BaseSettingsComponent,
        CommonSettingsComponent,
        DatabaseSettingsComponent,
        AgentSettingsComponent,
        ReceiverComponent,
        DecoratorComponent
    ]
})
export class SettingsModule {
}