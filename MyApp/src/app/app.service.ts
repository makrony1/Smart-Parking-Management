import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { CheckinRequest, CheckinResponse, CheckoutRequest,CheckoutResponse, Report } from './model/model';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  constructor(private http: HttpClient) {}

  getReport(): Observable<Report> {
    return this.http.get<Report>(`${environment.reportUrl}`);
  }

  checkin(body: CheckinRequest):Observable<CheckinResponse>{
    return this.http.post<CheckinResponse>(`${environment.checkinUrl}`, body);
  }

  checkout(body: CheckoutRequest):Observable<CheckoutResponse>{
    return this.http.post<CheckoutResponse>(`${environment.checkoutUrl}`, body);
  }
}