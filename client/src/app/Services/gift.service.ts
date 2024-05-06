import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from "rxjs";
import { giftList } from '../Models/giftList.model';
import { ObjectToRaffle } from '../Models/objectToRaffle.model';

// import { GiftList } from '../Models/GiftList.model';



@Injectable({
  providedIn: 'root'
})
export class GiftService {
  constructor(private httpClient: HttpClient) { }
  private reloadGiftSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  reloadGift$: Observable<boolean> = this.reloadGiftSubject.asObservable();

  GetAllGifts(): Observable<giftList[]> {
    let url = 'https://localhost:7154/api/Gift/GetAllGifts';
    // debugger
    return this.httpClient.get<giftList[]>(url);
  }
  GetAllGifts2(): Observable<giftList[]> {
    let url = 'https://localhost:7154/api/Gift/GetAllGifts2';
    // debugger
    return this.httpClient.get<giftList[]>(url);
  }
  getGiftById(number: number): Observable<giftList> {
    let url = 'http://localhost:19474/api/Gift/Get/' + number;
    return this.httpClient.get<giftList>(url);
  }

  saveGift(gift: giftList): Observable<boolean> {
    let url = 'http://localhost:19474/api/Gift/UpdateGift';
    //gift.image = "fefejhfk";
    return this.httpClient.post<boolean>(url, gift);
  }
  updateGift(gift: giftList): Observable<giftList> {
    let url = `https://localhost:7154/api/Gift/UpdateGift/?id=${gift.giftId}`;
    return this.httpClient.put<giftList>(url, gift);
  }

  addGift(gift: giftList): Observable<giftList> {
    let url = 'https://localhost:7154/api/Gift/AddGift';

    return this.httpClient.post<giftList>(url, gift)
  }

  DeleteGift(id: number): Observable<boolean> {

    // let url = `https://localhost:7154/api/Gift/DeleteGift/?id=$`;
    let url = `https://localhost:7154/api/Gift/DeleteGift/?id=${id}`;
    return this.httpClient.delete<boolean>(url)
  }
// Aa01/07/2004

  Raffele(giftName: string): Observable<ObjectToRaffle> {
    let url = `https://localhost:7154/api/Winner/RAFFELE?giftName=${giftName}`;
    return this.httpClient.post<ObjectToRaffle>(url, giftName);
  }
  create_report(): Observable<string []> {
    let url = "https://localhost:7154/api/Winner/ReportWinners";
    return this.httpClient.get<string[]>(url);
  }
//https://localhost:7154/api/Gift/SearchGiftsByAll?donor=1

SearchGift(name: string,  donor :string, numOfPurcheses :number): Observable<giftList[]> {
  let url = `https://localhost:7154/api/Gift/SearchGiftsByAll?name=${name}&donor=${donor}&numOfPurcheses=${numOfPurcheses}`;
  return this.httpClient.get<giftList[]>(url);
} 

  setReloadGift() {
    let flag = this.reloadGiftSubject.value;
    this.reloadGiftSubject.next(!flag);
  }

}



