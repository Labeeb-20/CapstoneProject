import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { CustomerdetailsComponent } from './components/customerdetails/customerdetails.component';
import { CustomersearchComponent } from './components/customersearch/customersearch.component';
import { LoanhistoryComponent } from './components/loanhistory/loanhistory.component';
import { ApplyloanComponent } from './components/applyloan/applyloan.component';
import { DashboadComponent } from './components/dashboad/dashboad.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CustomerdetailsComponent,
    CustomersearchComponent,
    LoanhistoryComponent,
    ApplyloanComponent,
    DashboadComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
