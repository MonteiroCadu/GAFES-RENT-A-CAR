import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PlaceDetailPageRoutingModule } from './place-detail-routing.module';

import { PlaceDetailPage } from './place-detail.page';
import { ToolBarComponent } from "../../../../shared/tool-bar/tool-bar.component";

@NgModule({
    declarations: [PlaceDetailPage],
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        PlaceDetailPageRoutingModule,
        ToolBarComponent
    ]
})
export class PlaceDetailPageModule {}
