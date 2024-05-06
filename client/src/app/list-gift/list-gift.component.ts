import { Component, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { GiftService } from '../Services/gift.service';
import { ConfirmationService, } from 'primeng/api';
import { Dialog, DialogModule } from 'primeng/dialog';
import { giftList } from '../Models/giftList.model';
import { ImageModule } from 'primeng/image';
import { Giver } from '../Models/Giver.model';
import { GiverService } from '../Services/giver.service';
import { DropdownModule } from 'primeng/dropdown';
import { Card } from '../Models/card.model';
@Component({
  selector: 'app-list-gift',
  templateUrl: './list-gift.component.html',
  styleUrls: ['./list-gift.component.css'],
  providers: [ConfirmationService, GiftService]

})
export class ListGiftComponent implements OnInit {
  
  @Input()
  forSearch: Card = new Card();
  @Input()
  isOpen1: boolean
  ind: number = 0;
  report: string[] = [];
  name: string = '';
  donorName: string = '';
  numOfPurcheses: number = 0;
  listGF: giftList[] = [];
  selectedIndex: number = 0;
  selectedGifts: giftList[];
  giftDialog: boolean = false;
  giftD: boolean = false;
  submitted: boolean;
  gift: giftList = new giftList();
  donorsToSelect: Giver[] = [];

  constructor(private giftService: GiftService, private giverService: GiverService, private confirmationService: ConfirmationService) { }
  ngOnInit() {
    this.giftService.reloadGift$.subscribe(x => {
      this.giftService.GetAllGifts().subscribe(data => this.listGF = data);
    });
    this.giverService.reloadGiver$.subscribe(x => {
      this.giverService.getGivers().subscribe(ld => this.donorsToSelect = ld);
    })
    console.log("donorsToSelect  in parent" + this.donorsToSelect);
  }

  openNew() {
    this.giftDialog = true
  }

  add(g: giftList) {
    this.listGF.push(g)
    this.giftService.setReloadGift();
  }

  delete(id: number) {
    this.giftService.DeleteGift(id)
      .subscribe(res => {
        if (res) {
          this.giftService.setReloadGift();
        }
      }
      )
  }
  Raffele(giftName: string) {
    this.giftService.Raffele(giftName)
      .subscribe(res => {
        var g = this.listGF.find(g => g.name == giftName);
        if (g)
          g.winFlag = true;
        alert(res.nameUser + "is the winner")
      }
      )
    this.giftService.setReloadGift();
  }

  create_report() {
    this.giftService.create_report().subscribe(rep => {
      this.isOpen1 = true;
      this.report = rep;
    })
    this.giftService.setReloadGift();
  }

  hideDialog1() {
    this.isOpen1 = false;
  }

  editGift(gift: giftList) {
    this.gift = { ...gift };
    this.giftDialog = true;
  }

  getGiftSearch() {
    this.giftService.SearchGift(this.name, this.donorName, this.numOfPurcheses).subscribe(
      (data) => {
        this.listGF = data;
        console.log(data);
        alert(data)
      },
    );
  }

  hideDialog() {
    this.giftD = false;
    this.submitted = false;
  }

}


