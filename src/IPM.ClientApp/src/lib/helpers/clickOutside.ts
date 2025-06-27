import type { Attachment } from "svelte/attachments"

interface Params {
  limit?: Node,
}

function clickOutside({ limit }: Params): Attachment {
  return (element) => {
    function onClick(e: Event) {
      if (!element.contains(e.target as Node)) {
        element.dispatchEvent(new CustomEvent("clickoutside"));
      }
    }
    if(limit != null) {
      limit.addEventListener("mousedown", onClick);
    } else {
      window.addEventListener("mousedown", onClick)
    }
    return () => {
      if(limit != null) {
        limit.removeEventListener("mousedown", onClick);
      } else {
        window.removeEventListener("mousedown", onClick)
      }
    }
  }
}

export default clickOutside;

