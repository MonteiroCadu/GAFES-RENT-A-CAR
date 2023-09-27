import { Component, OnInit } from '@angular/core';
import { Place } from 'src/app/models/places-model';
import { Reserva } from 'src/app/models/reserva-model';
import { AccountService } from 'src/app/services/Account.service';
import { PlacesService } from 'src/app/services/places.service';
import { ReservaService } from 'src/app/services/reserva.service';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.page.html',
  styleUrls: ['./offers.page.scss'],
})
export class OffersPage implements OnInit {


  public offers: Place[] = [];

  constructor(
    private placesService: PlacesService,
    private accountService: AccountService,
    private reservaService:ReservaService) { }

  ngOnInit() {
    
  }

  ionViewWillEnter() {
    //this.offers = this.placesService.places;
    let userID = this.accountService.ObterAccessTokenLogado().dados.userId;
    let reservas: Reserva[];

    this.reservaService.getReservas(userID)
    .subscribe( {
      next: (result) => {
       reservas = result;
       this.offers = this.placesService.places.filter((carro) => reservas.find(x => x.carroId === carro.id))
      },
      error : (erro) => {   
        alert('erro ao recuperar lista de reservas');     
        console.debug(erro);
      }
    });
  }

}
