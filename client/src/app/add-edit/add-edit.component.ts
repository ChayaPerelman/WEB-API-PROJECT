import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChange, SimpleChanges } from '@angular/core';
import { giftList } from '../Models/giftList.model';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { uniqueValidator } from '../infrastructure/validators/uniqueValidatore';
import { GiftService } from '../Services/gift.service';
import { ConfirmationService, } from 'primeng/api';
import { Giver } from '../Models/Giver.model';
import { GiverService } from '../Services/giver.service';
import { DropdownModule } from 'primeng/dropdown';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css'],
  providers: [GiftService]

})
export class AddEditComponent implements OnChanges, OnInit {
  @Input()
  giftL: giftList[] = [];
  @Input()
  isOpen: boolean;
  @Input()
  donorsToSelect: Giver[] = [];
  @Input()
  name: string;
  @Input()
  giftId: number;
  @Input()
  donorId: string;
  @Input()
  cost: number;
  @Input()
  isNew: boolean = false;
  @Input()
  gift: giftList = new giftList();
  @Input()
  listCategory: any[] = [0, 1, 2, 3];
  @Input()
  isVisible: boolean = false;
  @Output()
  isNewChange: EventEmitter<boolean> = new EventEmitter<boolean>()
  @Output()
  addGift: EventEmitter<giftList> = new EventEmitter<giftList>()
  @Output()
  isOpenChange: EventEmitter<boolean> = new EventEmitter<boolean>()
  submitted: boolean;
  copyGift: giftList = new giftList()
  change: SimpleChanges;

  constructor(private giftService: GiftService, private giverService: GiverService) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.change = changes;
    this.donorsToSelect = this.donorsToSelect;
    this.copyGift = Object.assign(this.copyGift, this.gift);
  }

  ngOnInit() {
    this.giftService.reloadGift$.subscribe(x => {
      this.giftService.GetAllGifts().subscribe(data => {
        this.giftL = data;
      });
    });
    this.giverService.reloadGiver$.subscribe(x => {
      this.giverService.getGivers().subscribe(ld => this.donorsToSelect = ld);
    })
    console.log("donorsToSelect in add-edit " + this.donorsToSelect);

  }

  saveGift() {
    this.submitted = true;
    if (this.gift.name.trim()) {
      if (this.gift.giftId) {
        this.giftService.updateGift(this.gift).subscribe(b => {
          console.log(b);
          this.giftService.GetAllGifts();
        }); this.giftService.GetAllGifts();
      }
      else {
        this.giftService.addGift(this.gift).subscribe(a => {
          this.giftService.GetAllGifts();
        });
      }
      this.isOpenChange.emit(this.isOpen);
      this.hideDialog();
    }
  }

  hideDialog() {
    this.isOpen = false;
    this.submitted = false;
  }

}
