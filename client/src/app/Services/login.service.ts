import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginDTO } from '../Models/LoginDTO.model';
import { User } from '../Models/User.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }
  private reloadLoginSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  reloadLogin$: Observable<boolean> = this.reloadLoginSubject.asObservable();
  
//   GetAllLogins():Observable<LoginDTO[]>{
//   let url = 'https://localhost:7154/api/Login/GetAllLogins';
//   // debugger
//   return this.httpClient.get<LoginDTO[]>(url);
// }
//   getLoginById(number: number) : Observable<LoginDTO>{
//     let url = 'http://localhost:19474/api/Login/Get/' + number;
//     return this.httpClient.get<LoginDTO>(url);
//   }

  // saveLogin(Login: LoginDTO) :Observable<boolean>{
  //   let url = 'http://localhost:19474/api/Login/UpdateLogin';
  //   //Login.image = "fefejhfk";
  //   return this.httpClient.post<boolean>(url, Login);
  // }
  // updateLogin(Login: LoginDTO) :Observable<LoginDTO>{
  //   let url = `https://localhost:7154/api/Login/UpdateLogin/?id=${Login.LoginId}`;   
  //   return this.httpClient.put<LoginDTO>(url, Login);
  // }

  addLogin(login: LoginDTO) :Observable<any> {
    let url = 'https://localhost:7154/api/User/login';
    return this.httpClient.post<any>(url, login)
  }

  DeleteLogin(id:number):Observable<boolean> {

   // let url = `https://localhost:7154/api/Login/DeleteLogin/?id=$`;
   let url = `https://localhost:7154/api/Login/DeleteLogin/?id=${id}`;
   return this.httpClient.delete<boolean>(url)
   }

   

  setReloadLogin(){
    let flag = this.reloadLoginSubject.value;
    this.reloadLoginSubject.next(!flag);
  }

}
