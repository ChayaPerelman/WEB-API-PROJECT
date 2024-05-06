import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import {  orderItemDTO } from '../Models/orderItemDTO.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  constructor(private httpClient: HttpClient) { }
  private reloadOrderSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  reloadOrder$: Observable<boolean> = this.reloadOrderSubject.asObservable();
  
  GetAllOrders():Observable<orderItemDTO[]>{
  let url = 'https://localhost:7154/api/Gift/GetAllGifts';
  // debugger
  return this.httpClient.get<orderItemDTO[]>(url);
}
  // getGiftById(number: number) : Observable<GiftList>{
  //   let url = 'http://localhost:19474/api/Gift/Get/' + number;
  //   return this.httpClient.get<GiftList>(url);
  // }

  // saveGift(gift: GiftList) :Observable<boolean>{
  //   let url = 'http://localhost:19474/api/Gift/UpdateGift';
  //   //gift.image = "fefejhfk";
  //   return this.httpClient.post<boolean>(url, gift);
  // }
  // updateGift(gift: GiftList) :Observable<GiftList>{
  //   let url = `https://localhost:7154/api/Gift/UpdateGift/?id=${gift.giftId}`;   
  //   return this.httpClient.put<GiftList>(url, gift);
  // }

  addToCart(gift: orderItemDTO) :Observable<orderItemDTO> {
    let url = 'https://localhost:7154/api/OrderItem/addToCart';
   
    return this.httpClient.post<orderItemDTO>(url, gift)
  }

  // DeleteGift(id:number):Observable<boolean> {

  //  // let url = `https://localhost:7154/api/Gift/DeleteGift/?id=$`;
  //  let url = `https://localhost:7154/api/Gift/DeleteGift/?id=${id}`;
  //  return this.httpClient.delete<boolean>(url)
  //  }

   

  setReloadOrder(){
    let flag = this.reloadOrderSubject.value;
    this.reloadOrderSubject.next(!flag);
  }

}
