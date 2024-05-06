import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {KeyFilterModule} from 'primeng/keyfilter';

import {DataViewModule} from 'primeng/dataview';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListGiftComponent } from './list-gift/list-gift.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddEditComponent } from './add-edit/add-edit.component';
import { BuyComponent } from './buy/buy.component';
import { PayComponent } from './pay/pay.component';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import {TabViewModule} from 'primeng/tabview';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputNumberModule } from 'primeng/inputnumber';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import {DialogModule} from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';
import { RatingModule } from 'primeng/rating';
import { ToolbarModule } from 'primeng/toolbar';
import { ConfirmationService } from 'primeng/api';
import { ListGiversComponent } from './list-givers/list-givers.component';
import { AddEdirGiversComponent } from './add-edir-givers/add-edir-givers.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {CardModule} from 'primeng/card';
import { giftList } from './Models/giftList.model';
import { GiftService } from './Services/gift.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { TokenInterceptor } from './interseptor';
import {ImageModule} from 'primeng/image';
import { OrderItemComponent } from './order-item/order-item.component';
import {PasswordModule} from 'primeng/password';
import {InputMaskModule} from 'primeng/inputmask';
import {CalendarModule} from 'primeng/calendar';
import {KnobModule} from 'primeng/knob';
import {MegaMenuModule} from 'primeng/megamenu';
import {TabMenuModule} from 'primeng/tabmenu';
import {MenuItem} from 'primeng/api';

@NgModule({
  declarations: [
    AppComponent,
    ListGiftComponent,
    AddEditComponent,
    BuyComponent,
    PayComponent,
    ListGiversComponent,
    AddEdirGiversComponent,
   ListGiftComponent,
    AddEditComponent,
    LoginComponent,
    RegisterComponent,
    OrderItemComponent
  ],

  
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ButtonModule,
    BrowserModule,
    FormsModule,
    TableModule,
    HttpClientModule,
    InputTextModule,
    DialogModule,
    ToolbarModule,
    ConfirmDialogModule,
    RatingModule,
    InputNumberModule,
    InputTextareaModule,
    RadioButtonModule,
    DropdownModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    CardModule,
    ImageModule,
    PasswordModule,
    CalendarModule,
    InputMaskModule,
    KnobModule,
    KeyFilterModule,
    DataViewModule,
    TabViewModule,
    MegaMenuModule,
    TabMenuModule,
  ],
  providers: [ConfirmationService,{ provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
