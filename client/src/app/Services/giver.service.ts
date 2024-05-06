import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject,Observable } from "rxjs";
import { giftList } from '../Models/giftList.model';
import { Giver } from '../Models/Giver.model';


@Injectable({
  providedIn: 'root'
})
export class GiverService {

  constructor(private httpClient: HttpClient) { }
  // private reloadGiverSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  // reloadGiver$: Observable<boolean> = this.reloadGiverSubject.asObservable();
 private reloadGiverSubject:BehaviorSubject<boolean> =new BehaviorSubject<boolean>(false)
 reloadGiver$:Observable<boolean>=this.reloadGiverSubject.asObservable()
getGivers():Observable<Giver[]>{
  let url = 'https://localhost:7154/api/Donor/GetAllDonors';
  // debugger
  return this.httpClient.get<Giver[]>(url);
}
getGiverById(number: number) : Observable<giftList[]>{
  let url = `https://localhost:7154/api/Donor/GetGiftsByDonorId/?id=${number}` ;
  return this.httpClient.get<giftList[]>(url);
}
updateDonor(giver: Giver) :Observable<giftList>{
  let url = `https://localhost:7154/api/Donor/UpdateDonor/?id=${giver.donorId}`;   
  return this.httpClient.put<giftList>(url, giver);
}
saveGiver(giver: Giver) :Observable<boolean>{
  let url = 'http://localhost:19474/api/Giver/UpdateGiver';
  return this.httpClient.post<boolean>(url, giver);
}

addGiver(giver: Giver) :Observable<Giver> {
  let url = 'https://localhost:7154/api/Donor/AddDonor';

  return this.httpClient.post<Giver>(url, giver)
}

delete(id:number):Observable<boolean> {

  let url = `https://localhost:7154/api/Donor/DeleteDonor/?id=${id}`;
  return this.httpClient.delete<boolean>(url)
  }

  
  SearchDonorsByAll(fName:string,lName:string,email:string,  giftName:string,  phoneNumber:string):Observable<Giver[]> {
    // let url = `https://localhost:7233/api/Donor/SelectDonorByNameEmailProduct?name=${firstName}&email=${email}&productName=${name}`;

  let url = `https://localhost:7154/api/Donor/SearchDonorsByAll?fName=${fName}&lName=${lName}&email=${email}&giftName=${giftName}&phoneNumber=${phoneNumber}`;
  return this.httpClient.get<Giver[]>(url)
  }




   

  setReloadGiver(){
    let flag = this.reloadGiverSubject.value;
    this.reloadGiverSubject.next(!flag);
  }

}

