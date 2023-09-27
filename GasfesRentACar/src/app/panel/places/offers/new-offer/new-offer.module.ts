import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { NewOfferPageRoutingModule } from './new-offer-routing.module';

import { NewOfferPage } from './new-offer.page';
import { ToolBarComponent } from "../../../../shared/tool-bar/tool-bar.component";

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        NewOfferPageRoutingModule,
        ToolBarComponent
    ],
    declarations: [NewOfferPage]
})
export class NewOfferPageModule {}
