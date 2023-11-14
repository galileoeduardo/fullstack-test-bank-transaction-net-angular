import { Inject, Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment'
import { Transaction } from '../transaction.model';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})

export class TransactionListComponent {
  public transactions: Transaction[] = [];
  private baseUrl = environment.baseUrl;
  

  constructor(http: HttpClient) {
    http.get<Transaction[]>(`${this.baseUrl}/transaction`).subscribe(result => {
      this.transactions = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
    console.log(this.transactions);
  }
 }
