import { Component, EventEmitter, Input, Output } from '@angular/core';
import { LoginService } from '../Services/login.service';
import { Router } from '@angular/router';
import { LoginDTO } from '../Models/LoginDTO.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  @Input()
  userLogin: LoginDTO = new LoginDTO()
  @Output()
  userLoginChange: EventEmitter<LoginDTO> = new EventEmitter<LoginDTO>()
  data: any;
  isOpen: boolean = true;

  constructor(public loginService: LoginService, private router: Router) { }

  register(){
    this.router.navigateByUrl('register');
  }
  
  login() {
    this.loginService.addLogin(this.userLogin).subscribe(d => {
      this.data = d;
      if (this.data != null) {
        sessionStorage.setItem("token", this.data.token);
        if (this.data.status == "manager")
          this.router.navigateByUrl('list-gift');
        else
          this.router.navigateByUrl('buy');
      }
    })
    if (this.data == null) {
      this.router.navigateByUrl('register');
    }
  }
}
