# Memtly Storybook Redesign Handoff

## Purpose

The user wants a Docker-buildable, self-hostable version of `/Users/hrivera/Git/memtly-clone` themed for a girl's birthday party for his daughter, Aria. The desired guest-facing site is a "Once Upon a Time" princess/storybook birthday experience with soft pastel colors, floral/balloon/castle party inspiration, and a magical invitation feel.

This handoff exists because the current implementation went in the wrong UI direction twice. The next agent should reset the guest-facing design direction rather than incrementally polishing the current UI.

## Suggested Skills

- `$impeccable` for design craft, critique, layout, color, and responsive polish.
- `build-web-apps:frontend-testing-debugging` or equivalent browser verification skill for screenshot-based iteration.
- Use normal repo/Docker tooling for build verification.

## User Feedback To Preserve

The user liked:

- A soft pastel princess/storybook palette.
- Guest-facing "Direction 2" from earlier design drafts.
- Admin-facing "Direction 3" from earlier design drafts.
- The theme can apply across the entire site if assets are shared.
- The Docker image should build and run locally.

The user rejected:

- "Material design pink castle vibes."
- Flat app-card/web-form treatment.
- The latest browser-panel mock direction.
- Treating `/Users/hrivera/Downloads/Generated image 2.png` as the design target. The user attached it with "wrong direction"; do not copy that UI.

## Actual Intended Design Direction

Think physical storybook party prop, not SaaS/app UI.

The guest-facing entry should feel like:

- A real party backdrop or birthday table scene, with balloons, roses, cake/cupcakes, gold castle/crown details, parchment, and storybook paper.
- A storybook invitation or open book as the primary object, not a rectangular dashboard page.
- Soft blush, ivory parchment, dusty rose, rose-gold, warm gold, and gentle floral greens.
- "Once Upon a Time" typography should be storybook/blackletter or fairytale display, but readable on mobile.
- Controls should feel embedded into the invitation/page, not Bootstrap cards. Use labels such as "Add Your Photos", "Enter Gallery Key", "View Gallery", but make them feel like part of a party keepsake.
- Mobile should be designed first as a party invitation page. It should not look like a compressed desktop web panel.

Avoid:

- Generic castle icons scattered around.
- A flat pink material-design theme.
- Navbar-heavy layout on the guest entry page.
- Big web-app cards, boxed sections, and dashboard-like memory cards.
- Fake decorations that do not feel integrated into the scene.
- Treating sample/photo placeholders as real guest memories unless clearly decorative.

## Inspiration Images

Original inspiration images from the conversation:

- `/var/folders/6k/rt803h9n1x92ytnwvbydgy5r0000gn/T/codex-clipboard-6e7d840d-eb8f-4e22-bf24-56170c473bb7.png`
- `/var/folders/6k/rt803h9n1x92ytnwvbydgy5r0000gn/T/codex-clipboard-9253b9ff-4841-4571-80bb-85476a2294c9.png`
- `/var/folders/6k/rt803h9n1x92ytnwvbydgy5r0000gn/T/codex-clipboard-9bced523-b176-4317-bf4e-df0e089f1eda.png`

Important non-target image:

- `/Users/hrivera/Downloads/Generated image 2.png`
- The user attached this with "wrong direction." Do not use it as the final target. It is useful only as an example of what not to do: polished but still app/browser-panel oriented.

## Current Repo State

Workspace:

- `/Users/hrivera/Git/memtly-clone`
- Submodule/core app: `/Users/hrivera/Git/memtly-clone/Memtly.Core/Memtly.Core`

Current changes already made by prior agent:

- Added Storybook theme enum and comparer entries:
  - `Memtly.Core/Memtly.Core/Enums/Themes.cs`
  - `Memtly.Core/Memtly.Core/Comparers/ThemesComparer.cs`
- Added/modified theme/static asset wiring:
  - `Memtly.Core/Memtly.Core/Memtly.Core.csproj`
  - `Memtly.Core/Memtly.Core/src/themes/storybook.css`
  - `Memtly.Core/Memtly.Core/wwwroot/images/storybook-backdrop.jpg`
  - `Memtly.Core/Memtly.Core/wwwroot/fonts/UnifrakturCook-Bold.ttf`
  - `Memtly.Core/Memtly.Core/wwwroot/fonts/GreatVibes-Regular.ttf`
- Modified views:
  - `Memtly.Core/Memtly.Core/Views/Shared/_Layout.cshtml`
  - `Memtly.Core/Memtly.Core/Views/Gallery/Login.cshtml`
  - `Memtly.Core/Memtly.Core/Views/Home/Index.cshtml`
  - `Memtly.Core/Memtly.Core/Views/Gallery/Index.cshtml`
- Modified local app config:
  - `Memtly.Community/appsettings.json`
- Added project context:
  - `PRODUCT.md`

The current UI in these files should be considered a rejected draft. It can be reused for plumbing and theme registration, but the visual structure should be redesigned.

## Config Notes

`Memtly.Community/appsettings.json` was changed to enable a single default gallery, the Storybook theme, full-width gallery, camera uploads, and no first-load identity modal.

There are local access credentials/keys in config. Do not expose them in public docs or commits. If needed, inspect `Memtly.Community/appsettings.json` locally.

## Technical Behavior To Preserve

- Docker image must build:

```bash
DOCKER_HOST=unix:///Users/hrivera/.orbstack/run/docker.sock /Applications/OrbStack.app/Contents/MacOS/xbin/docker build -f Memtly.Community/Dockerfile -t memtly-community:storybook .
```

- Preview command:

```bash
DOCKER_HOST=unix:///Users/hrivera/.orbstack/run/docker.sock /Applications/OrbStack.app/Contents/MacOS/xbin/docker rm -f memtly-storybook-preview >/dev/null 2>&1 || true
DOCKER_HOST=unix:///Users/hrivera/.orbstack/run/docker.sock /Applications/OrbStack.app/Contents/MacOS/xbin/docker run -d --rm --name memtly-storybook-preview -p 5050:5000 memtly-community:storybook
```

- Local preview URL:

```text
http://localhost:5050
```

- Root path redirects to the single-gallery login flow because `Single_Gallery_Mode` is enabled.
- `Gallery/Login.cshtml` is likely the main guest entry surface.
- `Gallery/Index.cshtml` is the post-key upload/gallery surface and should retain the same theme language.
- Do not break the existing gallery key POST flow in `src/modules/gallery-selector/index.js`.

## Verification Commands

Asset build:

```bash
cd /Users/hrivera/Git/memtly-clone/Memtly.Core/Memtly.Core
npm run production
```

Docker build:

```bash
cd /Users/hrivera/Git/memtly-clone
DOCKER_HOST=unix:///Users/hrivera/.orbstack/run/docker.sock /Applications/OrbStack.app/Contents/MacOS/xbin/docker build -f Memtly.Community/Dockerfile -t memtly-community:storybook .
```

Screenshots:

```bash
cd /Users/hrivera/Git/memtly-clone
npx playwright screenshot --browser=chromium --viewport-size=1440,1000 http://localhost:5050 /tmp/memtly-storybook-desktop.png
npx playwright screenshot --browser=chromium --viewport-size=390,844 http://localhost:5050 /tmp/memtly-storybook-mobile.png
npx playwright screenshot --browser=chromium --viewport-size=320,720 http://localhost:5050 /tmp/memtly-storybook-mobile-320.png
```

## Known Build Warnings

The app currently builds, but warnings appear:

- Existing `SQLitePCLRaw.lib.e_sqlite3` vulnerability advisory during restore/build.
- Existing bundle-size warnings from Webpack.
- Existing nullable/obsolete warnings in the ASP.NET project.

These were not introduced by the redesign attempt and were not resolved.

## Recommended Next-Agent Plan

1. Start by showing or drafting a new visual direction in a low-risk way before deep implementation. The key question is: "Does this feel like a physical birthday storybook/invitation, not a web app?"
2. Rework `Gallery/Login.cshtml` first. This is the actual first guest surface in single-gallery mode.
3. Hide or radically simplify guest nav. A small unobtrusive access/admin affordance is okay, but the first impression should be the storybook party scene.
4. Use the existing `storybook-backdrop.jpg` only if it helps. Replace or regenerate it if needed. The design must not rely on CSS-only ornaments.
5. Use the locally bundled fonts if they work, but prioritize readability and taste over blackletter novelty.
6. Treat `storybook.css` as disposable. Preserve tokens/theme registration if useful, but rewrite the layout if needed.
7. After each substantial pass, screenshot desktop, 390px mobile, and 320px mobile. The user is judging rendered UI, not code.
8. Keep admin/account surfaces functional and calmer. The user liked a different admin direction, but the latest frustration is guest-facing UI.

## Current Preview Screenshots From Rejected Draft

These are not targets; they show the rejected state:

- `/tmp/memtly-storybook-desktop-2.png`
- `/tmp/memtly-storybook-mobile-final.png`
- `/tmp/memtly-storybook-mobile-320-final.png`

Use them only to understand what not to continue.
