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
      limit.addEventListener("click", onClick);
    } else {
      window.addEventListener("click", onClick)
    }
    return () => {
      if(limit != null) {
        limit.removeEventListener("click", onClick);
      } else {
        window.removeEventListener("click", onClick)
      }
    }
  }
}

export default clickOutside;

