import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Reserva } from '../models/reserva-model';
import { RetornoGenerico } from '../models/retornoGenerico-model';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

  private baseURL: string = environment.apiURL;
  private url : string = `${this.baseURL}/Reserva`;  

  constructor(
      private http : HttpClient ) {         
  }

  public getReservas(userId:number) : Observable<Reserva[]> {
    return this.http.get<Reserva[]>(this.url+`/userId/${userId}`);
  }

  public getReservaAtiva(carroID:string) : Observable<Reserva> {    
    return this.http.get<Reserva>(this.url+`/ativa/${carroID}`);
  }

  public getReservaAtivaByUser(carroID:string, userID:number) : Observable<Reserva> {    
    return this.http.get<Reserva>(this.url+`/ativa/${carroID}/userID/${userID}`);
  }

  public reservar(userId: number, carroID: string) : Observable<RetornoGenerico<Reserva>> {
    return this.http.post<RetornoGenerico<Reserva>>(this.url,{userid:userId, carroId: carroID});
  }
  
  public liberarReservar(reservaId:number) : Observable<RetornoGenerico<Reserva>> {
    return this.http.put<RetornoGenerico<Reserva>>(this.url+`/${reservaId}`,null);
  }

}
