import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { CustomerdetailsComponent } from './components/customerdetails/customerdetails.component';
import { CustomersearchComponent } from './components/customersearch/customersearch.component';
import { LoanhistoryComponent } from './components/loanhistory/loanhistory.component';
import { ApplyloanComponent } from './components/applyloan/applyloan.component';
import { DashboadComponent } from './components/dashboad/dashboad.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

const routes: Routes =[

  {
    path:"",
    component: CustomersearchComponent,
  }
]


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CustomerdetailsComponent,
    CustomersearchComponent,
    LoanhistoryComponent,
    ApplyloanComponent,
    DashboadComponent,
    
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
