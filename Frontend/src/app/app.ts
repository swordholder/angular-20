import { Component, inject, OnInit, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface HelloResponse {
  message: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private http = inject(HttpClient);

  // Make sure these three properties exist in the class
  apiMessage = signal<string>('');
  loading = signal<boolean>(false);
  errorMessage = signal<string>('');

  private readonly apiUrl = 'http://localhost:5199/api/hello';

  ngOnInit(): void {
    this.fetchMessage();
  }

  fetchMessage(): void {
    this.loading.set(true);
    this.errorMessage.set('');

    this.http.get<HelloResponse>(this.apiUrl).subscribe({
      next: (data) => {
        this.apiMessage.set(data.message);
        this.loading.set(false);
      },
      error: (err) => {
        console.error('API Error:', err);
        this.errorMessage.set('Could not connect to .NET API on port 5199.');
        this.loading.set(false);
      }
    });
  }
}