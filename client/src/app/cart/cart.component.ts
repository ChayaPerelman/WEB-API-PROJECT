
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { giftList } from '../Models/giftList.model';
import { GiftService } from '../Services/gift.service';
import { BuyService } from '../Services/buy.service';
import { ObjectToConnect } from '../Models/ObjectToConnect.model';

import { Button } from 'primeng/button';
import { orderItemDTO } from '../Models/orderItemDTO.model';
import { orderItem } from '../Models/orderItem.model';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class BuyComponent {

  @Input()
  cart: orderItem = new orderItem();
  listCart: orderItem[] = []

  constructor(private buyService: BuyService) { }

  ngOnInit() {
    this.buyService.reloadBuy$.subscribe(x => {
      this.buyService.getCart().subscribe(data => this.listCart = data);
    });
  }

  delete(number: number) {
    this.buyService.delete(number).subscribe(a => {
      alert("succesfuly delete")
    }
    )
  }
}
