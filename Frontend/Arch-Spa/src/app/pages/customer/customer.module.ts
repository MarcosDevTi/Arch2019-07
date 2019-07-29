import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { NewCustomerComponent } from './new-customer/new-customer.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    CustomerListComponent,
    NewCustomerComponent,
  ],
  imports: [
    SharedModule,
    CustomerRoutingModule,
  ]
})
export class CustomerModule { }
