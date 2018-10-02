import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Account } from './account';
import { MessageService } from './message.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })

export class AccountService {

  private accountsUrl = 'api/Account/Get';

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  getAccounts(): Observable<Account[]> {
    return this.http.get<Account[]>(this.accountsUrl)
      .pipe(
        tap(accounts => this.log('fetched accounts')),
        catchError(this.handleError('getAccounts', []))
      );
  }

  getAccountNo404<Data>(id: number): Observable<Account> {
    const url = `${this.accountsUrl}/?id=${id}`;
    return this.http.get<Account[]>(url)
      .pipe(
        map(accounts => accounts[0]), // returns a {0|1} element array
        tap(a => {
          const outcome = a ? `fetched` : `did not find`;
          this.log(`${outcome} account id=${id}`);
        }),
      catchError(this.handleError<Account>(`getAccount id=${id}`))
      );
  }

  getAccount(id: number): Observable<Account> {
    const url = `${this.accountsUrl}/${id}`;
    return this.http.get<Account>(url).pipe(
      tap(_ => this.log(`fetched account id=${id}`)),
      catchError(this.handleError<Account>(`getAccount id=${id}`))
    );
  }
  
  addAccount(account: Account): Observable<Account> {
    return this.http.post<Account>(this.accountsUrl, account, httpOptions).pipe(
      tap((account: Account) => this.log(`added account w/ id=${account.ID}`)),
      catchError(this.handleError<Account>('addAccount'))
    );
  }

  deleteAccount(account: Account | number): Observable<Account> {
    const id = typeof account === 'number' ? account : account.ID;
    const url = `${this.accountsUrl}/${id}`;

    return this.http.delete<Account>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted account id=${id}`)),
      catchError(this.handleError<Account>('deleteAccount'))
    );
  }

  updateAccount(account: Account): Observable<any> {
    return this.http.put(this.accountsUrl, account, httpOptions).pipe(
      tap(_ => this.log(`updated account id=${account.ID}`)),
      catchError(this.handleError<any>('updateAccount'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      this.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }

  private log(message: string) {
    this.messageService.add(`AccountService: ${message}`);
  }
}
