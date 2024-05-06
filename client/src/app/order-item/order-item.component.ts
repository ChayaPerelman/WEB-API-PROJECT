import { Component, EventEmitter, Input, Output } from '@angular/core';
import { orderItem } from '../Models/orderItem.model';
import { BuyService } from '../Services/buy.service';
import { ToName } from '../Models/ToName.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: ['./order-item.component.css']
})
export class OrderItemComponent {

  @Input()
  listCart: orderItem[] = []
  @Input()
  cart: orderItem = new orderItem()
  @Input()
  Name: ToName = new ToName()
  ifTrue: boolean = false
  @Input()
  payDialog: boolean
  @Output()
  payDialogChange: EventEmitter<boolean> = new EventEmitter<boolean>()

  constructor(private buyService: BuyService, private router: Router) { }

  ngOnInit() {
    this.buyService.reloadBuy$.subscribe(x => {
      this.buyService.getCart().subscribe(data => {
        this.listCart = data
      })
      this.buyService.getName().subscribe(data => {
        this.Name = data
      });
    });
  }

  delete(number: number) {
    alert(number)
    this.buyService.delete(number).subscribe(res => {
        console.log("delete");
    });
    this.buyService.setReloadBuy()
  }

  getName() {
    this.buyService.getName().subscribe(res => {
      console.log(res.name + "   ❤   " + res.count);
    });
    this.buyService.setReloadBuy()
  }

  return() {
    this.router.navigateByUrl('buy');
  }

  pay() {
    this.ifTrue = true
  }

}
