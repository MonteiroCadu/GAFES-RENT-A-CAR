import { Injectable } from '@angular/core';
import { Place } from '../models/places-model'

@Injectable({
  providedIn: 'root'
})
export class PlacesService {
  private _places: Place[] = [
    new Place(
      'p1',
      'Cruizer',
      'Sedan top de linha Chevrolet',
      'https://www.chevrolet.com.br/content/dam/chevrolet/mercosur/brazil/portuguese/index/cars/cars-subcontent/02-images/cruze-sport6-rs-carros.jpg?imwidth=419',
      400
    ),
    new Place(
      'p2',
      'Onix',
      'Hatch mais utilizado do brasil',
      'https://www.chevrolet.com.br/content/dam/chevrolet/mercosur/brazil/portuguese/index/cars/cars-landing/05-images/jpg/onix-hb.jpg?imwidth=419',
      300
    ),
    new Place(
      'p3',
      'Argo',
      'O compacto da Fiat é veiculo versatil e economico',
      'https://fiat.grupoamazonas.com.br/wp-content/uploads/2021/08/fiat-argo-768x589.jpg',
      250
    ),
    new Place(
      'p4',
      'Toro',
      'Pick-up dat Fiat, para quatro passageiros e caçamba com uma boa capacidade de carga',
      'https://fiat.grupoamazonas.com.br/wp-content/uploads/2021/08/fiat-toro-768x589.jpg',
      250
    )
  ];

  get places() : Place[] {
    return [...this._places];
  }

  constructor() { }
}
