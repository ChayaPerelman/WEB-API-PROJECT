import { Component } from '@angular/core';
import { giftList } from './Models/giftList.model';
import { TabViewModule } from 'primeng/tabview';
import { MegaMenuModule } from 'primeng/megamenu';
import { MegaMenuItem, MenuItem } from 'primeng/api';
import { TabMenuModule } from 'primeng/tabmenu';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'project';
  giftDailog: boolean = false;
  submitted: boolean;
  gift: giftList = new giftList()
  items: MenuItem[];
  constructor(router: Router) { }

  ngOnInit() {
    this.items = [
      { label: 'register', icon: 'pi pi-fw pi-home' },
      { label: 'Calendar', icon: 'pi pi-fw pi-calendar' },
      { label: 'Edit', icon: 'pi pi-fw pi-pencil' },
      { label: 'Documentation', icon: 'pi pi-fw pi-file' },
      { label: 'Settings', icon: 'pi pi-fw pi-cog' }
    ];
  }
}


