import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OfferBookingsPageRoutingModule } from './offer-bookings-routing.module';

import { OfferBookingsPage } from './offer-bookings.page';
import { ToolBarComponent } from "../../../../shared/tool-bar/tool-bar.component";

@NgModule({
    declarations: [OfferBookingsPage],
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        OfferBookingsPageRoutingModule,
        ToolBarComponent
    ]
})
export class OfferBookingsPageModule {}
