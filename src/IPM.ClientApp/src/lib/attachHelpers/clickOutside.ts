import type { Attachment } from "svelte/attachments"

interface Options {
  limit?: Node,
}

function clickOutside(handler: () => void, opts?: Options): Attachment {
  return (element) => {
    function onClick(e: Event) {
      if (!element.contains(e.target as Node)) {
        // element.dispatchEvent(new CustomEvent("clickoutside"));
        handler();
      }
    }
    if(opts?.limit != null) {
      opts?.limit.addEventListener("mousedown", onClick);
    } else {
      window.addEventListener("mousedown", onClick)
    }
    return () => {
      if(opts?.limit != null) {
        opts?.limit.removeEventListener("mousedown", onClick);
      } else {
        window.removeEventListener("mousedown", onClick)
      }
    }
  }
}

export default clickOutside;

