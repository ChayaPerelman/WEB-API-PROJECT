import { Component, Input, OnInit } from '@angular/core';
import { GiverService } from '../Services/giver.service';
import { Giver } from '../Models/Giver.model';
import { ConfirmationService } from 'primeng/api';
import { giftList } from '../Models/giftList.model';

@Component({
  selector: 'app-list-givers',
  templateUrl: './list-givers.component.html',
  styleUrls: ['./list-givers.component.css'],
  providers: [ConfirmationService, GiverService]
})
export class ListGiversComponent implements OnInit {

  ind: number = 0;
  listGivers: Giver[] = [];
  selectedIndex: number = 0;
  selectedGivers: Giver[];
  giverDialog: boolean = false;
  fName: string
  lName: string
  email: string
  giftName: string
  phoneNumber: string
  giverD: boolean = false;
  submitted: boolean;
  listGiftById: giftList[] = []
  giver: Giver = new Giver()
  
  constructor(private giverService: GiverService, private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.giverService.reloadGiver$.subscribe(x => {
      this.giverService.getGivers().subscribe(data => {
        this.listGivers = data
      });
    });
  }

  openNew() {
    this.giverDialog = true
  }

  add(g: Giver) {
    this.listGivers.push(g)
  }

  delete(id: number) {
    this.giverService.delete(id)
      .subscribe(res => {
        if (res) {
          this.giverService.setReloadGiver();
        }
      }
      )
  }

  getGiverById(id: number) {
    this.giverService.getGiverById(id)
      .subscribe(data => {
        if (data) {
          this.listGiftById = data
          console.log(this.listGiftById);
          this.listGiftById
          this.listGiftById.forEach(element => {
            alert("" + element.name.toString())
          });
          this.giverService.setReloadGiver();
        }
      }
      )
  }

  editgiver(giver: Giver) {
    this.giver = { ...giver };
    this.giverDialog = true;
  }

  SearchDonorsByAll() {
    this.giverService.SearchDonorsByAll(this.fName, this.lName, this.email, this.giftName, this.phoneNumber)
      .subscribe(res => {
        if (res) {
          this.listGivers = res;
          this.giverService.setReloadGiver();
        }
      })
  }

  hideDialog() {
    this.giverDialog = false;
    this.submitted = false;
  }
  
}





