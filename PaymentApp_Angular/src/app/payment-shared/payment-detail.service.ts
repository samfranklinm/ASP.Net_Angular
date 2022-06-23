import { Injectable } from '@angular/core';
import { PaymentDetail } from './payment-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PaymentDetailService {
  formData: PaymentDetail;

  readonly rootUrl = 'http://localhost:1473/api';
  payments: PaymentDetail[];

  constructor(private http: HttpClient) {}

  postPaymentDetail(formData: PaymentDetail) {
    // makes a POST request to the backend
    console.log(formData);
    return this.http.post(this.rootUrl + '/PaymentDetail', formData);
  }

  putPaymentDetail(formData: PaymentDetail) {
    // makes a PUT request to the backend to modify entry
    return this.http.put(
      this.rootUrl + '/PaymentDetail/' + formData.PMId,
      formData
    );
  }

  deletePaymentDetail(PMId: number) {
    // makes a PUT request to the backend to modify entry
    return this.http.delete(this.rootUrl + '/PaymentDetail/' + PMId);
  }

  refreshList() {
    // referesh the list on the right to show a list with newly added information
    this.http
      .get(this.rootUrl + '/PaymentDetail')
      .toPromise()
      .then((res) => (this.payments = res as PaymentDetail[]));
  }
}
