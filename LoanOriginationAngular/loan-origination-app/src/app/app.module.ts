import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
<<<<<<< HEAD
=======
// import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

>>>>>>> 0165f5a20b2d42cbbf4acf39a013704433248149
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { CustomerdetailsComponent } from './components/customerdetails/customerdetails.component';
import { CustomersearchComponent } from './components/customersearch/customersearch.component';
import { LoanhistoryComponent } from './components/loanhistory/loanhistory.component';
import { ApplyloanComponent } from './components/applyloan/applyloan.component';
import { DashboadComponent } from './components/dashboad/dashboad.component';
<<<<<<< HEAD
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
=======
//import { AppRoutingModule } from './components/app-routing/app-routing.component';
import { RouterModule, Routes } from '@angular/router';
import { LoginService } from './services/login/login.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { ContentComponent } from './components/content/content.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboadComponent },
  { path: 'customer-detail', component: CustomerdetailsComponent },
  { path: 'customer-search', component: CustomersearchComponent },
  { path: 'apply-loan', component: ApplyloanComponent }
];
>>>>>>> 0165f5a20b2d42cbbf4acf39a013704433248149
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
    BrowserModule,
<<<<<<< HEAD
    HttpClientModule,
    FormsModule
=======
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    HeaderComponent,
    FooterComponent,
    ContentComponent,
    RouterModule.forRoot(routes)
>>>>>>> 0165f5a20b2d42cbbf4acf39a013704433248149
  ],
  providers: [LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
