import { NewCustomerComponent } from './new-customer/new-customer.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerListComponent } from './customer-list/customer-list.component';


const routes: Routes = [
  {path: '', component: CustomerListComponent},
  {path: 'new', component: NewCustomerComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
