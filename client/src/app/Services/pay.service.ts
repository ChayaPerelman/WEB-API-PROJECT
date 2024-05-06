import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PayService {

  
  constructor(private httpClient: HttpClient) { }
  private reloadPaySubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  reloadPay$: Observable<boolean> = this.reloadPaySubject.asObservable();

  payService():Observable<number>{
    let url = 'https://localhost:7154/api/Order/pay';
    return this.httpClient.post<number>(url, 4);
  }
     

  setReloadOrder(){
    let flag = this.reloadPaySubject.value;
    this.reloadPaySubject.next(!flag);
  }

}
