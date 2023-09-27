import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NavController } from '@ionic/angular';
import { Place } from 'src/app/models/places-model';
import { AccountService } from 'src/app/services/Account.service';
import { PlacesService } from 'src/app/services/places.service';
import { ReservaService } from 'src/app/services/reserva.service';

@Component({
  selector: 'app-offer-bookings',
  templateUrl: './offer-bookings.page.html',
  styleUrls: ['./offer-bookings.page.scss'],
})
export class OfferBookingsPage implements OnInit {
  public place?: Place;

  constructor( 
    private router: ActivatedRoute,
    private navController: NavController,
    private placesService: PlacesService,
    private accountService: AccountService,
    private reservaService: ReservaService) { }

  ngOnInit() {
    this.router.paramMap.subscribe(param => {
      if(!param.has('placeId')) {
        this.navController.back();
        return;
      }
      this.place = this.placesService.places.find(p => p.id === param.get('placeId'));
    });
  }

  onLiberarReserva() {
    let userId = this.accountService.ObterAccessTokenLogado().dados.userId;
    this.reservaService.getReservaAtivaByUser(this.place!.id,userId)
    .subscribe( {
      next: (reserva) => {
       this.reservaService.liberarReservar(reserva.id)       
       .subscribe( {
        next: (result) => {          
          this.navController.back();
        },
        error : (erro) => {   
          alert('erro ao recuperar lista de reservas');     
          console.debug(erro);
        }
      });
      
      },
      error : (erro) => {   
        alert('erro ao recuperar lista de reservas');     
        console.debug(erro);
      }
    });
  }

}
