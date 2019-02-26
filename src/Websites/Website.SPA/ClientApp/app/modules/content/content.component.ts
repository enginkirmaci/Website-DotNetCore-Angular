import { Component, Input } from '@angular/core';
//import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'content',
    templateUrl: './content.component.html'
})
export class ContentComponent {
    @Input() data: any;
    @Input() layout: number;
}