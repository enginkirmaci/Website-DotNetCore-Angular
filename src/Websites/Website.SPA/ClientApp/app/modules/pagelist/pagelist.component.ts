import { Component, Input } from "@angular/core";

@Component({
    selector: "pagelist",
    templateUrl: "./pagelist.component.html"
})
export class PagelistComponent {
    @Input() data: any;
    @Input() layout: number;
}