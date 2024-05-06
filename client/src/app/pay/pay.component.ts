import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PayService } from '../Services/pay.service';
import { PasswordModule } from 'primeng/password';
import { InputMaskModule } from 'primeng/inputmask';
import { KeyFilterModule } from 'primeng/keyfilter';
import { CalendarModule } from 'primeng/calendar';
@Component({
  selector: 'app-pay',
  templateUrl: './pay.component.html',
  styleUrls: ['./pay.component.css']
})
export class PayComponent {

  @Input()
  payDialog: boolean;
  @Input()
  payName: string;
  @Input()
  payPassword: number;
  @Input()
  pValidateOnly: boolean = false
  @Output()
  payDialogChange: EventEmitter<boolean> = new EventEmitter<boolean>()
  submitted: boolean;
  isOpen22: boolean;

  constructor(public payService: PayService) { }

  save() {
    this.payService.payService().subscribe(userId => console.log("the userid" + userId))
    this.payDialogChange.emit(this.isOpen22);
  }
}
