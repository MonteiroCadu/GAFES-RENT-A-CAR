import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { User } from "../models/user-model";
import { RetornoPaginado } from "../models/Retorno-paginado-model";
import { RetornoGenerico } from "../models/retornoGenerico-model";

@Injectable({
    providedIn:'root'
})
export class UserService {
    private baseURL: string = environment.apiURL;
    private url : string = `${this.baseURL}/Usuario`;  

    constructor(
        private http : HttpClient ) {         
    }

    public insertUser(user: User) : Observable<RetornoGenerico<User>> {
        return this.http.post<RetornoGenerico<User>>(this.url,user);
    }

    public updatetUser(user: User, idUser:number) : Observable<RetornoGenerico<User>> {
       
        return this.http.put<RetornoGenerico<User>>(this.url+`/${idUser}`,user);
    }

    public deleteUser(idUser:number) : Observable<RetornoGenerico<null>> {
       
        return this.http.delete<RetornoGenerico<null>>(this.url+`/${idUser}`);
    }

    public getAll() : Observable<RetornoPaginado<User>> {
        return this.http.get<RetornoPaginado<User>>(this.url);
    }

    public getById(id:number) : Observable<User> {
        return this.http.get<User>(this.url+`/${id}`);
    }
}