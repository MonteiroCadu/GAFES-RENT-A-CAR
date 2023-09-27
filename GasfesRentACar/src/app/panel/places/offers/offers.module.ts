import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OffersPageRoutingModule } from './offers-routing.module';

import { OffersPage } from './offers.page';
import { ToolBarComponent } from "../../../shared/tool-bar/tool-bar.component";


@NgModule({
    declarations: [OffersPage],
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        OffersPageRoutingModule,
        ToolBarComponent
    ]
})
export class OffersPageModule {

  
}
