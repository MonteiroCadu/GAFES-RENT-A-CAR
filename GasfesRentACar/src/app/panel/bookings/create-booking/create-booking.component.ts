import { Component, Input, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { Place } from 'src/app/models/places-model';

@Component({
  selector: 'app-create-booking',
  templateUrl: './create-booking.component.html',
  styleUrls: ['./create-booking.component.scss'],
})
export class CreateBookingComponent  implements OnInit {
  @Input() 
  place!:Place;

  constructor(private modalCtr: ModalController) { }

  ngOnInit() {}
  confirm(){
    this.modalCtr.dismiss({message:'Book confirmed'},'confirm');
  }
  cancel(){
    this.modalCtr.dismiss(null,'cancel');
  }

}
