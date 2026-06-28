# Product

## Register

brand

## Users

Primary users are birthday-party guests, family members, and the event host using the public gallery on phones during or shortly after the party. Guests need to open a simple link or QR code, understand where they are, view memories, and upload photos or videos without needing to learn the product. The host/admin surface remains secondary and should stay practical, readable, and conventionally product-like.

## Product Purpose

This Memtly build is a self-hosted, Docker-deployable event memory gallery for Aria's birthday party. It should turn the guest-facing gallery into a "once upon a time" storybook-princess experience while preserving the underlying Memtly upload, viewing, sharing, and administration workflows. Success means guests feel they have entered Aria's birthday storybook, can confidently upload memories, and the owner can still deploy and maintain it through the existing Docker host.

## Brand Personality

Whimsical, storybook, celebratory. The interface should feel like an opened fairy-tale book prepared for a child's birthday: soft pinks, aged paper, gilt details, floral accents, and a castle motif. It should be charming and theatrical without becoming hard to read, childish to the point of clutter, or fragile as a web application.

## Anti-references

Avoid generic SaaS blue Bootstrap, admin-dashboard chrome on guest pages, Disney-like character copying, heavy toy-store saturation, fake luxury wedding styling, unreadable blackletter body text, and decorative flourishes that obscure upload or gallery actions. The theme should not rely on manually patching files inside a running container after deployment.

## Design Principles

1. Make the gallery feel like a party artifact, not default software.
2. Keep the path to upload and view memories obvious at all times.
3. Use fairy-tale motifs as framing and atmosphere, never as obstacles.
4. Preserve Docker-friendly, source-controlled configuration and assets.
5. Let admin and maintenance screens stay calm and functional unless explicitly themed later.

## Accessibility & Inclusion

Target WCAG AA contrast for guest-facing text and controls. Preserve keyboard access, visible focus states, reduced-motion preferences, and touch targets appropriate for party guests using phones. Decorative fonts may be used for headings and theme moments, but forms, buttons, help text, and labels must remain easy to read.
