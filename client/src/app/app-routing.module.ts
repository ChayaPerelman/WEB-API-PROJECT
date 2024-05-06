import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListGiftComponent } from './list-gift/list-gift.component';
import { PayComponent } from './pay/pay.component';
import { BuyComponent } from './buy/buy.component';
import { ListGiversComponent } from './list-givers/list-givers.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { OrderItemComponent } from './order-item/order-item.component';

const routes: Routes = [
  {path:'', redirectTo:'login', pathMatch:'full'},
  {path:'list-gift',component:ListGiftComponent},
  {path:'list-givers',component:ListGiversComponent},
  {path:'order-item',component:OrderItemComponent},
  {path:'buy',component:BuyComponent,children:[{path:'pay',component:PayComponent}]},
  {path:'register',component:RegisterComponent},
  {path:'login',component:LoginComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
