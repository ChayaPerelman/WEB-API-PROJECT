import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Observable } from 'rxjs/internal/Observable';
import { RegisterDTO } from '../Models/RegisterDTO.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private httpClient: HttpClient) { }
  private reloadRegisterSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false)
  reloadRegister$: Observable<boolean> = this.reloadRegisterSubject.asObservable()
  getGivers(): Observable<RegisterDTO[]> {
    let url = 'https://localhost:7154/api/Donor/GetAllDonors';
    // debugger
    return this.httpClient.get<RegisterDTO[]>(url);
  }
  //  getGiverById(number: number) : Observable<Giver>{
  //    let url = 'https://localhost:7154/api/Donor/GetGiftsByDonorId' + number;
  //    return this.httpClient.get<Giver>(url);
  //  }

  //  saveGiver(giver: Giver) :Observable<boolean>{
  //    let url = 'http://localhost:19474/api/Giver/UpdateGiver';
  //    return this.httpClient.post<boolean>(url, giver);
  //  }

  Register(user: RegisterDTO): Observable<boolean> {
    let url ='https://localhost:7154/api/User/register';
  
    return this.httpClient.post<boolean>(url, user)
  }

  //  delete(id:number):Observable<boolean> {

  //    let url = `https://localhost:7154/api/Donor/DeleteDonor/?id=${id}`;
  //    return this.httpClient.delete<boolean>(url)
  //    }






  setReloadUser() {
    let flag = this.reloadRegisterSubject.value;
    this.reloadRegisterSubject.next(!flag);
  }
}
