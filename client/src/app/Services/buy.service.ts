import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from "rxjs";
import { giftList } from '../Models/giftList.model';
import { ObjectToConnect } from '../Models/ObjectToConnect.model';
import { orderItem } from '../Models/orderItem.model';
import { ToName } from '../Models/ToName.model';

@Injectable({
  providedIn: 'root'
})
export class BuyService {

  constructor(private httpClient: HttpClient) { }
  private reloadBuySubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  reloadBuy$: Observable<boolean> = this.reloadBuySubject.asObservable();

  addToCart(obj:ObjectToConnect): Observable<boolean> {
    let url = 'https://localhost:7154/api/OrderItem/addToCart';
    return this.httpClient.post<boolean>(url, obj)
  }

  getCart(): Observable<orderItem[]> {
    let url = 'https://localhost:7154/api/OrderItem/GetCart';
    return this.httpClient.get<orderItem[]>(url);
  }


  delete(number: number): Observable<boolean> {

    let url = `https://localhost:7154/api/OrderItem/RemoveFromCart?id=${number}`;

    return this.httpClient.delete<boolean>(url)
  }
  getName(): Observable<ToName> {

    let url = `https://localhost:7154/api/OrderItem/GetName`;

    return this.httpClient.get<ToName>(url)
  }

 
//https://localhost:7154/api/OrderItem/GetName

  setReloadBuy() {
    let flag = this.reloadBuySubject.value;
    this.reloadBuySubject.next(!flag);
  }
}
