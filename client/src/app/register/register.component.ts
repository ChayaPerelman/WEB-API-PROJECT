import { Component, EventEmitter, Input, Output } from '@angular/core';
import { RegisterDTO } from '../Models/RegisterDTO.model';
import { RegisterService } from '../Services/register.service';
import { Router } from '@angular/router';
import { BuyService } from '../Services/buy.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  @Input()
  user: RegisterDTO = new RegisterDTO;
  @Output()
  userChange: EventEmitter<RegisterDTO> = new EventEmitter<RegisterDTO>()
  isOpen: boolean = true;
  data: any;

  constructor(public registerService: RegisterService, private router: Router, public BuyService: BuyService) { }

  register() {
    this.registerService.Register(this.user).subscribe(d => {
      this.data = d
      if (this.data == true) {
        sessionStorage.setItem("token", JSON.stringify(this.data));
        console.log(this.user.userPassword);
        this.router.navigateByUrl('login');
      }
      else {
        alert("נכשל, נסה שוב😴")
      }
    })
  }
}
