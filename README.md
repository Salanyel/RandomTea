# RandomTea


# Git workflow
TL;DR : Create a branch for your ticket. Work on it. Push the branch. Create a pull request. Squash and Merge.

## Cheatsheet

### Hotfix on Develop
1. `git checkout Develop`
2. `git pull`
3. Work
4. Commit and push
5. If there are conflicts (somebody commited in the meantime), rebase on top of origin/Develop then commit

### Feature branch
1. Create feature branch from Develop
2. Work on it
3. Rebase it on top of Develop
4. Create a pull request via github
5. Squash and Merge when it is validated

Detailed example:
```
# Create new branch on top of Develop
git checkout Develop
git pull
git checkout -b feature/myFeatureBranch

# Work...
git add .
git commit -m "[Minor] stuff"
git add .
git commit -m "[Bugfix] fixing my stuff"

# Your feature branch should be clean. No garbage commits. You can squash unwanted commits with others by using an interactive rebase. Do it in an external git UI, or :
# interactive rebase of the top 42 commits. (obviously, change 42 by whatever number of commits there are in your branch)
git rebase -i HEAD ~42

# Do a pull request on github
# Once validated, merge via Squash and Merge option
```
