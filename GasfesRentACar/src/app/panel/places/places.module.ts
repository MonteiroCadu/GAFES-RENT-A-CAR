import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PlacesPageRoutingModule } from './places-routing.module';

import { PlacesPage } from './places.page';
import { ToolBarComponent } from "../../shared/tool-bar/tool-bar.component";

@NgModule({
    declarations: [PlacesPage],
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        PlacesPageRoutingModule,
        ToolBarComponent
    ]
})
export class PlacesPageModule {}
