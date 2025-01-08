// See https://svelte.dev/docs/kit/types#app.d.ts
// for information about these interfaces
declare global {
	namespace App {
		// interface Error {}
		// interface Locals {}
		// interface PageData {}
		// interface PageState {}
		// interface Platform {}
	}
  type EventSelectElements = Event & {
  currentTarget: EventTarget & HTMLSelectElement;
 };
  type EventSubmitElements = SubmitEvent & {
    currentTarget: EventTarget & HTMLFormElement;
  }
  type WindowMouseEvent = MouseEvent & {
    currentTarget: EventTarget & Window;
  }
}

export {};
