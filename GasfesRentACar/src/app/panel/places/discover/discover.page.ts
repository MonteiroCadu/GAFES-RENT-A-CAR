import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { Place } from 'src/app/models/places-model';
import { PlacesService } from 'src/app/services/places.service';

@Component({
  selector: 'app-discover',
  templateUrl: './discover.page.html',
  styleUrls: ['./discover.page.scss'],
})
export class DiscoverPage implements OnInit {

  public loadedPlaces: Place[] = [];
  constructor(private placesService: PlacesService,private  modalCtr: ModalController) { }

  ngOnInit() {
    this.loadedPlaces = this.placesService.places;
  }

  onBookPlace() {
    //this.modalCtr.create({});
  }

}
