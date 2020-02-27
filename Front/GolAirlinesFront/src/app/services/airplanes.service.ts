import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Airplane } from '../models/airplane';
import { Resultado } from '../models/Resultado';

@Injectable({
  providedIn: 'root'
})
export class AirplanesService {

  apiUrl : string = 'http://localhost:56934';
  constructor(
    private httpClient : HttpClient
  ) { }

  getAirplane = () : Observable<Airplane[]> => {
    return this.httpClient.get<Airplane[]>(`${this.apiUrl}/api/Airplane`);
  }

  getAirplaneById = (codAviao : number) : Observable<Airplane> => {
    return this.httpClient.get<Airplane>(`${this.apiUrl}/api/Airplane/${codAviao}`);
  }

  addAirplane = (airplane : Airplane) : Observable<Resultado> => {
    return this.httpClient.post<Resultado>(`${this.apiUrl}/api/Airplane`, airplane);
  }

  updateAirplane = (airplane : Airplane) : Observable<Resultado> => {
    return this.httpClient.put<Resultado>(`${this.apiUrl}/api/Airplane`, airplane);
  }

  excluirAirplane = (codAviao: number) : Observable<Resultado> => {
    return this.httpClient.delete<Resultado>(`${this.apiUrl}/api/Airplane/${codAviao}`);
  }
}
