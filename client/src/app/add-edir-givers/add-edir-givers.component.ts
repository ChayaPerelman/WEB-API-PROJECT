import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { GiftService } from '../Services/gift.service';
import { Giver } from '../Models/Giver.model';
import { GiverService } from '../Services/giver.service';

@Component({
  selector: 'app-add-edir-givers',
  templateUrl: './add-edir-givers.component.html',
  styleUrls: ['./add-edir-givers.component.css']
})
export class AddEdirGiversComponent {

  @Input()
  giverList: Giver[] = [];
  @Input()
  isOpen: boolean;
  @Input()
  giver: Giver = new Giver()
  @Input()
  ind: number = 6;
  @Output()
  isOpenChange: EventEmitter<boolean> = new EventEmitter<boolean>()
  @Output()
  addGift: EventEmitter<Giver> = new EventEmitter<Giver>()
  copyGiver: Giver = new Giver()
  change: SimpleChanges;
  submitted: boolean;

  constructor(private giftService: GiverService) { }

  ngOnInit() {
    this.giftService.reloadGiver$.subscribe(x => {
      this.giftService.getGivers().subscribe(data => this.giverList = data);

    })
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    this.change = changes;
    this.copyGiver = Object.assign(this.copyGiver, this.giver);
  }

  saveGiver() {
    this.submitted = true;
    if (this.giver.firstName.trim()) {
      if (this.giver.donorId) {
        this.giftService.updateDonor(this.giver).subscribe(b => {
          this.giftService.setReloadGiver();
        });
      }
      else {
        this.giftService.addGiver(this.giver).subscribe(a => {
          this.giftService.setReloadGiver();
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
