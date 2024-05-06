import { Component, EventEmitter, Input, Output } from '@angular/core';
import { giftList } from '../Models/giftList.model';
import { GiftService } from '../Services/gift.service';
import { BuyService } from '../Services/buy.service';
import { ObjectToConnect } from '../Models/ObjectToConnect.model';
import { DataViewModule } from 'primeng/dataview';

import { Button } from 'primeng/button';
import { orderItemDTO } from '../Models/orderItemDTO.model';
import { orderItem } from '../Models/orderItem.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.css']
})
export class BuyComponent {

  @Input()
  payDialog: boolean;
  @Input()
  gift: giftList = new giftList();
  @Input()
  isOpen: boolean;
  @Input()
  object: ObjectToConnect = new ObjectToConnect();
  @Output()
  payDialogChange: EventEmitter<boolean> = new EventEmitter<boolean>();
  listGF: giftList[] = [];
  selectedIndex: number = 0;
  selectedGifts: giftList[];
  giftDialog: boolean = false;
  ifTrue: boolean = false
  listCart: orderItem[] = []
  demo: orderItem = new orderItem()
  giftD: boolean = false;
  submitted: boolean;
  sortOrder: number;
  sortField: string;
  oi: orderItem = new orderItem();

  constructor(private buyService: BuyService, private giftService: GiftService, private router: Router) { }

  ngOnInit() {

    this.giftService.reloadGift$.subscribe(x => {
      this.giftService.GetAllGifts2().subscribe(data => this.listGF = data);
    });
    this.buyService.reloadBuy$.subscribe(x => {
      this.buyService.getCart().subscribe(data => this.listCart = data);
    });
  }

  addToCart(gift: giftList) {
    this.submitted = true;
    this.object.GiftId = gift.giftId;
    this.object.image = gift.image;
    this.buyService.addToCart(this.object).subscribe(data => {
      if (data != true) {
        alert(gift.giftId + "failed because: " + data)
      }
      else {
        alert(gift.giftId + "success")
      }
    });
    this.buyService.setReloadBuy();
    this.hideDialog();
  }

  hideDialog() {
    this.giftD = false;
    this.submitted = false;
  }
  cart() {
    this.router.navigateByUrl('order-item');
    this.buyService.setReloadBuy();
  }

  add(qty: number) {
    this.object.qty = qty + 1
    this.buyService.setReloadBuy();
  }

  pay() {
    this.ifTrue = true
  }

  reduce(qty: number) {
    this.object.qty = qty - 1
    this.buyService.setReloadBuy();
  }

  hideDialog2() {
    this.isOpen = false;
    this.submitted = false;
  }

  Cancel(id: number) {
    this.buyService.delete(id)
      .subscribe(res => {
        if (res) {
          this.buyService.setReloadBuy();
        }
      })
  }
}
