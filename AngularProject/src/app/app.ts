import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App {

  consultaForm: FormGroup;
  resultados: any[] = [];
  error: string = '';

  constructor(private fb: FormBuilder, private http: HttpClient) {

    this.consultaForm = this.fb.group({
      program_1: ['', Validators.required],
      term_code_entry: ['', Validators.required],
    });
  }
  protected readonly title = 'Consulta de imformes';
  consultarPagos() {
    this.error = '';
    this.resultados = [];

    const payload = this.consultaForm.value;

    this.http.post<any[]>('/consulta-pagos', payload).subscribe({
      next: (data) => {
        this.resultados = data;
      },
      error: (err) => {
        this.error = 'Error al consultar pagos. Verifica los datos o intenta más tarde.';
        console.error(err);
      },
    });
  } 
}
