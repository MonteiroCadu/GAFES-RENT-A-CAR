import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { ActivatedRoute } from '@angular/router';
import {CreateBookingComponent} from '../../../bookings/create-booking/create-booking.component';
import { Place } from 'src/app/models/places-model';
import { PlacesService } from 'src/app/services/places.service';
import { ReservaService } from 'src/app/services/reserva.service';
import { AccountService } from 'src/app/services/Account.service';

@Component({
  selector: 'app-place-detail',
  templateUrl: './place-detail.page.html',
  styleUrls: ['./place-detail.page.scss'],
})
export class PlaceDetailPage implements OnInit {
  showButtonReserve: boolean = true;

   place?: Place;
  constructor(
    private modalCtrl: ModalController,
    private router:ActivatedRoute,
    private placeService: PlacesService,
    private reservaService: ReservaService,
    private accountService: AccountService) { }

  ngOnInit() {
    const placeId = this.router.snapshot.paramMap.get('placeId');
    this.place = this.placeService.places.find(x => x.id === placeId);
  }

  ionViewWillEnter(){
    

    let carroIDstr = this.router.snapshot.paramMap.get('placeId');
    this.reservaService.getReservaAtiva(carroIDstr!)
    .subscribe( {
      next: (result) => {
        //console.log(result);
        if(result === null) {
          this.showButtonReserve = true;
          
        } else {
          this.showButtonReserve = false;
        }
      },
      error : (erro) => {
        
        console.debug(erro);
        return false;
      }
    });
  }

  async onReservar() {
    let userId = this.accountService.ObterAccessTokenLogado().dados.userId;
    this.reservaService.reservar(userId, this.place!.id)
    .subscribe( {
      next: (result) => {
       alert('Reserva realizada com sucesso');
       this.showButtonReserve = false;
      },
      error : (erro) => {   
        alert('Erro ao realizar a reserva');     
        console.debug(erro);
      }
    });
  }

  showReleaseReserveButton() {
    return true;
  }

  showReservButton() {
    
  }

}
