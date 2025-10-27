import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrl: './order-detail.component.scss',
  standalone: false
})
export class OrderDetailComponent implements OnInit {
  id? : string | null;
  constructor(
    private route: ActivatedRoute
  ){}
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

  }

}
